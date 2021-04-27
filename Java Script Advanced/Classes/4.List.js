class List{
    constructor(){
        this.collector =new Map();
        this.count = 0;
        this.size = 0;
    }

    


    add(element){
        this.collector.set(this.count, element);
        this.count++;
        this.size = this.collector.size;
        const sorted = Array.from(this.collector.entries()).sort((a, b) => a[1] - b[1]); 
        for(let i = 0; i<this.collector.size;i++){
            this.collector.set(i, sorted[i][1]);
        }

    }
    remove(index){
        if(index >= this.collector.size){
            throw new Error("Cant remova at invalid index.");
        }
        this.collector.delete(index);

        for(let i = index; i< this.collector.size;i++){
            this.collector.set(i, this.collector.get(i+1));
            this.collector.delete(i+1);
        }
        this.size = this.collector.size;
    }

    get(index){
        if(index >= this.collector.size){
            throw new Error("Cant find element at invalid index.");
        }
        return this.collector.get(index);
    }
    
   
}


let list = new List();
console.log(list.hasOwnProperty('size'));
list.add(5);

list.add(3);

console.log(list.get(0));

list.remove(0);
console.log(list.get(0));
