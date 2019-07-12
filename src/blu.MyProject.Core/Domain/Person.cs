using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace blu.MyProject.Domain
{
    [Table("Person")]
    public class Person : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonState State { get; set; }
        public Person()
        { }
        
        public Person(string name, int age) : this()
        {
            Name = name;
            Age = age;
        }

        public enum PersonState : byte
        {
            Open = 0,
            Completed = 1
        }
    }
}
