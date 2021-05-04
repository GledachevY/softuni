function solution (){
    Array.prototype.last = function(){
        return this[this.length-1];
    };
    Array.prototype.skip = function(num){
        const arr = [];
        for(let i = num; i < this.length;i++){
            arr.push(this[i]);
        }
        return arr;
    }
    Array.prototype.take = function(num){
        const arr = [];
        for(let i = 0; i < num;i++){
            arr.push(this[i]);
        }
        return arr;
    }
    Array.prototype.sum = function(){
        const result = this.reduce((acc,curr) => acc +=curr);
        return result;
    }
    Array.prototype.average = function(){
        const result = this.reduce((acc,curr) => acc +=curr);
        return result / this.length;
    }

   // const myArr = [8,8,31,1,78];

   // console.log(myArr.average());
}

//solution();