function myFunc(input) {
    let nums = [];
    let symbols = [];
    for (const item of input) {
        if (isNaN(item)) {
            symbols.push(item);
        } else {
            nums.push(item);
        }
    }
    if (symbols.length > 0) {
        for (let i = 0; i < symbols.length; i++) {
            let lastNum;
            let lastMinusOneNum;
            let result;
            if (nums.length >= 2) {
                switch (symbols[i]) {
                    case '+':
                         lastNum = nums[nums.length-1];
                         lastMinusOneNum = nums[nums.length - 2];
                        result = lastMinusOneNum + lastNum;
                    break;
                    case '-':
                         lastNum = nums[nums.length-1];
                         lastMinusOneNum = nums[nums.length - 2];
                        result = lastMinusOneNum - lastNum;
                    break;
                    case '*':
                         lastNum = nums[nums.length-1];
                         lastMinusOneNum = nums[nums.length - 2];
                        result = lastMinusOneNum * lastNum;
                    break;
                    case '/':
                         lastNum = nums[nums.length-1];
                         lastMinusOneNum = nums[nums.length - 2];
                        result = lastMinusOneNum / lastNum;
                    break;
                }
            }else{
                console.log("Error: not enough operands!");
                break;
            }

            nums.pop();
            nums.pop();
            nums.push(result);
            symbols.shift();

            if(symbols.length === 0){
                break;
            }else{
                i=-1;
            }

        }
    }
    if(nums.length > 1){
        console.log("Error: too many operands!");
    }
    if(nums.length ===1 && symbols.length===0){
        console.log(nums[0]);
    }

}

myFunc([15,
    '*']   
);