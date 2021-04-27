class Company {
    constructor() {
        this.departaments = [];
    }

    addEmployee(username, salary, position, departament) {
        if (this.departaments.some((dep) => dep.name === departament)) {

            const foundDepartament = this.departaments.find((dep) => dep.name === departament);
            foundDepartament.pushEmployee(username, salary, position);
        } else {
            const newDepartament = new Departament(departament);
            newDepartament.pushEmployee(username, salary, position);
            this.departaments.push(newDepartament);
        }
    }

    getDeps() {
        return this.departaments;
    }

    bestDepartament() {
        const sortedDepartaments = this.departaments.sort((a, b) => b.getAverageSalary() - a.getAverageSalary());
        const bestDepartamentObject = sortedDepartaments[0];



        let output = `Best Department is: ${sortedDepartaments[0].name}
Average salary: ${sortedDepartaments[0].getAverageSalary()} \n`;

        for(let emp of bestDepartamentObject.getBstEMpSal()){
            output += `${emp.username} ${emp.salary} ${emp.position}\n`;
        }

        return output;

    }

}

class Departament {
    constructor(name) {
        this._name = name;
        this.employees = [];
    }

    getAverageSalary() {
        return ((this.employees.reduce((acc, cur) => acc += cur.salary, 0)) / this.employees.length).toFixed(2);
    }

    get name() {
        return this._name;
    }

    pushEmployee(username, salary, position) {
        this.employees.push(new Employee(username, salary, position));
    }

    getBstEMpSal(){
        this.employees.sort((a,b) => b.salary - a.salary);
        this.employees.sort((a,b) => a.username - b.username);
        return this.employees;
    }
}

class Employee {
    constructor(username, salary, position) {
        this.username = username;
        this.salary = salary;
        this.position = position;
    }
}

// let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("tanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");

// console.log(c.bestDepartament());