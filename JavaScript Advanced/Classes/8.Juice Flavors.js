function solve(juicyArray) {

    function filter(map, pred) {
        const result = new Map();
        for (let [k, v] of map) {
            if (pred(k, v)) {
                result.set(k, v);
            }
        }
        return result;
    }

    const juices = new Map();

    for (let juicy of juicyArray) {

        const juicyInfo = juicy.split('=>'.trim());

        const juicyName = juicyInfo[0];
        const juicyQuantity = Number(juicyInfo[1]);

        if(juices.has(juicyName)){
            const oldQuantity = juices.get(juicyName);
            if(oldQuantity < 1000){

                juices.delete(juicyName);
            }
            juices.set(juicyName,juicyQuantity + oldQuantity);
        }else{
            juices.set(juicyName, juicyQuantity);
        }


    }

    const result = filter(juices,(k,v) => v > 1000);

    const iterable = result.entries();

    for(let[k,v] of iterable){
        console.log(`${k}=> ${Math.floor(v/1000)}`);
    }

    
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);