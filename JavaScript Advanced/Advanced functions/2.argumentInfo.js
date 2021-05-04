function solve(...args) {
    const arguments = Array.from(args);

    const resultArr = {};

    for (const argument of arguments) {
        const type = typeof (argument);
        const value = argument;

        console.log(`${type}: ${value}`);

        if(resultArr[type] === undefined){

            resultArr[type]=1;
        }else{
            resultArr[type]++;
        }
    }

    Object.keys(resultArr).sort((a,b) => resultArr[b] - resultArr[a]).forEach(k => console.log(`${k} = ${resultArr[k]}`))

}

solve('cat', 42, function () { console.log('Hello world!'); });



