

function myFunc(nums){
    let sum = 0;
    let inverseSum = 0;
    let outputString = "";
    for(let i = 0; i < nums.length;i++){
        sum += nums[i];
        inverseSum += 1 / nums[i];
        let asd = "";
        asd = nums[i].toString();
        outputString = outputString + asd;
    }

    console.log(sum);
    console.log(inverseSum);
    console.log(outputString);
}
const arr = [2,5,6,88];
myFunc(arr);