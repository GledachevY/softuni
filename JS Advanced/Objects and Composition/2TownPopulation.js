function myFunc(input){
    const resultArr = [];
    for(let info of input){
       let splitted = info.split('<->');

        let name = splitted[0];
        let population = Number(splitted[1]);

        if(!resultArr[name]){
            resultArr[name] = population;
        }else{
            resultArr[name] += population;
        }
    }

    for(let name in resultArr){
        console.log(`${name}: ${resultArr[name]}`);
    }
}

myFunc(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);