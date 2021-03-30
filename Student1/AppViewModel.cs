using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace Student1
{
    public class AppViewModel : INotifyPropertyChanged
    {
        AppCont db;
        Command add;
        Command edit;
        Command delete;
        IEnumerable<Student> students;

        public IEnumerable<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged("Students");
            }
        }

        public AppViewModel()
        {
            db = new AppCont();
            db.Students.Load();
            Students = db.Students.Local.ToBindingList();
        }

        public Command Add
        {
            get
            {
                return add ??
                  (add = new Command((obj) =>
                  {
                      AddWindow addWindow = new AddWindow(new Student());
                      if (addWindow.ShowDialog() == true)
                      {
                          Student student = addWindow.Student;
                          db.Students.Add(student);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        
        public Command Edit
        {
            get
            {
                return edit ??
                  (edit = new Command((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      Student student = selectedItem as Student;

                      Student vm = new Student()
                      {
                          Id = student.Id,
                          FIO = student.FIO,
                          Faculty = student.Faculty,
                          Maths = student.Maths,
                          Physics = student.Physics,
                          Essay = student.Essay,
                          Sum = student.Sum
                      };
                      AddWindow addWindow = new AddWindow(vm);


                      if (addWindow.ShowDialog() == true)
                      {
                          student = db.Students.Find(addWindow.Student.Id);
                          if (student != null)
                          {
                              student.FIO = addWindow.Student.FIO;
                              student.Faculty = addWindow.Student.Faculty;
                              student.Maths = addWindow.Student.Maths;
                              student.Physics = addWindow.Student.Physics;
                              student.Essay = addWindow.Student.Essay;
                              student.Sum = addWindow.Student.Sum;
                              db.Entry(student).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        
        public Command Delete
        {
            get
            {
                return delete ??
                  (delete = new Command((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      Student student = selectedItem as Student;
                      db.Students.Remove(student);
                      db.SaveChanges();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
