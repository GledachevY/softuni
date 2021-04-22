function myFunc(arr){
    let sum =0;
    sum += Number(arr[0]) + Number(arr[arr.length - 1]);
    return sum;
}

console.log(myFunc(['20', '30', '40']));