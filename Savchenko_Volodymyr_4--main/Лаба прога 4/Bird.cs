using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_прога_4
{
    public abstract class Bird
    {
        public int age { get; set; }
        public Bird(int age)
        {
            this.age = age;
        }
        public virtual void Info()
        {
            Console.WriteLine($"Птах: {ToString()}, його вiк: {age} рокiв");
        }

    }
     public abstract class FlyBird : Bird
    {
        public int flyheight { get; set; }
        public FlyBird(int age, int flyheight) : base (age)
        {
            this.flyheight = flyheight;
        }
    }
    public abstract class NoFlyBird : Bird
    {
        public int runspeed { get; set; }
        public NoFlyBird(int age, int runspeed) : base (age)
        {
            this.runspeed = runspeed;
        }
    }
    public class Eagle : FlyBird
    {
        public Eagle(int age, int flyheight) : base(age, flyheight)
        {
            this.flyheight = flyheight;
        }
        public override string ToString()
        {
            return "Eagle";
        }
        public override void Info()
        {
            Console.WriteLine($"Птах: {ToString()}, його вiк: {age} рокiв, вiн лiтає на висоту: {flyheight} метрiв");
        }
    }
    public class Parrot : FlyBird
    {
        public Parrot(int age, int flyheight) : base(age, flyheight)
        {
            this.flyheight = flyheight;
        }
        public override string ToString()
        {
            return "Parrot";
        }
        public override void Info()
        {
            Console.WriteLine($"Птах: {ToString()}, його вiк: {age} рокiв, вiн лiтає на висоту: {flyheight} метрiв");
        } 
    }
    public class Ostrich : NoFlyBird
    {
        public Ostrich(int age, int runspeed) : base(age, runspeed)
        {
            this.runspeed = runspeed;
        }
        public override string ToString()
        {
            return "Ostrich";
        }
        public override void Info()
        {
            Console.WriteLine($"Птах: {ToString()}, його вiк: {age} рокiв, вiн бiжить зi швидкiстю: {runspeed} км/год");
        }
    }
    public class Penguin : NoFlyBird
    {
        public Penguin(int age, int runspeed) : base(age, runspeed)
        {
            this.runspeed = runspeed;
        }
        public override string ToString()
        {
            return "Penguin";
        }
        public override void Info()
        {
            Console.WriteLine($"Птах: {ToString()}, його вiк: {age} рокiв, вiн бiжить зi швидкiстю: {runspeed} км/год");
        }
    }
}
