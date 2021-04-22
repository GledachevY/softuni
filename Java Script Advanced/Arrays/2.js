function myFunc(arr, step){
  
    return arr.filter((value, index, array) => index % step ===0);
}

console.log(myFunc(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));