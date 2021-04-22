function myFunc(arr){
    arr.sort((a,b) => a- b);
    let resArr = [];
    if(arr.length % 2 === 0){
        for(let i =arr.length / 2 ;i < arr.length;i++){
            resArr.push(arr[i]);
        }
    }else{
        for(let i =Math.floor( arr.length / 2 );i < arr.length;i++){
            resArr.push(arr[i]);
        }
    }
    return resArr;
}

console.log(myFunc([3, 19, 14, 7, 2, 19, 6]));