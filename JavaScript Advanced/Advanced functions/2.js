function solution(num){

    let sum = num;
    function add(numToAdd){
        let result = sum + numToAdd;
        return result;
    }

    return add;
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
