
function myFunck(input) {
    let re = new RegExp('[A-Za-z]\\w+', 'g');
    let result = "";

    const arr = input.match(re);
    for (let i = 0; i < arr.length; i++) {
        let word = arr[i];
        
        if( i  == arr.length - 1){
            result = result + word.toUpperCase();
        }else{
            result = result + word.toUpperCase() + ', ';
        }
    }

    console.log(result);
}
myFunck('Hi, how are you?');
