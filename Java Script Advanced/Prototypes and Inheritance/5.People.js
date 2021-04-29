function solution(){
    class Employee{
        constructor(name,age){
            this.name = name,
            this.age = age;
            this.salary = 0;
            this.tasks = [];
            this._currentActivity = 0;

        }

        
        getSalary(){
            return this.salary;
        }

        work(){
            if(this._currentActivity >= this.tasks.length){
                this._currentActivity = 0;
            }
            const result = this.tasks[this._currentActivity];
            this._currentActivity++;
            return result;
        }
        collectSalary(){
            return `${this.name} received ${this.salary} this month.`;
        }
    }

    class Junior extends Employee{
        constructor(name,age){
            super(name,age);
            this.tasks = [`${this.name} is working on a simple task.`];
            this.salary = 0;
        }
    }

    class Senior extends Employee{
        constructor(name,age){
            super(name,age);
            this.tasks = [`${this.name} is working on a complicated task.`,
            `${this.name} is taking time off work.`,
            `${this.name} is supervising junior workers.`
            ];
            this.salary = 0;
        }
    }

    class Manager extends Employee{
        constructor(name, age){
            super(name,age);
            this.tasks = [`${this.name} scheduled a meeting`,
            `${this.name} is preparing a quarterly report.`
            ];
            this._salary = 0;
            this.dividend = 0;
        }
        collectSalary(){
            return `${this.name} received ${this.salary + this.dividend} this month.`;
        }

    }

    return{Employee, Junior, Senior, Manager};
}

const asd = solution (); 
const junior = new asd.Junior('Ivan',25); 
 
console.log(junior.work());  
console.log(junior.work());  
 
junior.salary = 5813; 
console.log(junior.collectSalary());  
 
const sinior = new asd.Senior('Alex', 31); 
 
console.log(sinior.work());  
console.log(sinior.work());  
console.log(sinior.work());  
console.log(sinior.work());  
 
sinior.salary = 12050; 
console.log(sinior.collectSalary());  
 
const manager = new asd.Manager('Tom', 55); 
 
manager.salary = 15000; 
console.log(manager.collectSalary());  
manager.dividend = 2500; 
console.log(manager.collectSalary());  
