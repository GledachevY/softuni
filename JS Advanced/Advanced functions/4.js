function solve(empJSON, criteria) {
    const emplyees = JSON.parse(empJSON);

    function predicat(element) {
        const result = criteria.split('-');
        const prop = result[0];
        const value = result[1];

        return element[prop] === value;

    }

    const emps = emplyees.filter(em => predicat(em));
    
    const empToPRint = emps.reduce((acc, cur)=>{
        acc.id.push(Number(cur.id) - 1);
        acc.name.push(cur.first_name + ' ' + cur.last_name);
        acc.email.push(cur.email);
        return acc;
    }, { id: [], name: [], email: [] });
   

    for(let i = 0; i< empToPRint.name.length; i++){
        console.log(`${empToPRint.id[i]}. ${empToPRint.name[i]} - ${empToPRint.email[i]}`);
    }

}


const example = `[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
}, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
},  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
}]`


console.log(solve(example, 'gender-Female'));