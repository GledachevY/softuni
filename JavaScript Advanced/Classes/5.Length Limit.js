class Stringer{
    constructor(innerString, innerLength){
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length){
        this.innerLength += length;
        if(this.innerLength < 0 ){
            this.innerLength = 0;
        }
    }
    decrease(length){
        this.innerLength -= length;
        if(this.innerLength < 0 ){
            this.innerLength = 0;
        }
    }

    toString(){
        if(this.innerLength  === 0){
            return '...';
        }else if(this.innerString.length > this.innerLength){
            return `${this.innerString.slice(0, this.innerLength)}...`;
        }else{
            return this.innerString;
        }
    }

}

const asd = new Stringer('Victor', 5);
console.log(asd.toString());