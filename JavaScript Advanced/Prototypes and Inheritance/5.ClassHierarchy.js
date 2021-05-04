function result(){
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }
    
        get area(){};
    
        changeUnits(value) {
            this.units = value;
        }
    
        toString() {
            return `Figures units: ${this.units}`;
        }
    }
    
    class Circle extends Figure {
        constructor(radius) {
            super();
            this.radius = radius
        }
        get area(){
            return Math.PI * this.radius**2;
        }
    
        toString(){
            return `Figures units: ${this.units} Area: ${this.area} - radius: ${this.radius}`;
        }
    }
    
    class Rectangle extends Figure{
        constructor(width, height,units){
            super(units);
            if(this.units === 'mm'){
                this.width = width*10;
            this.height = height*10;
            }else if(units === 'm'){
                this.width = width/100;
                this.height = height/100;
            }else{
                this.width = width;
                this.height = height;
            }
            
        }
        changeUnits(unitss){
            if(unitss === 'mm'){
                this.width = this.width*10;
            this.height = this.height*10;
            }else if(unitss === 'm'){
                this.width = this.width/100;
                this.height = this.height/100;
            }else {
                this.width = this.width;
                this.height = this.height;
            }
        }
    
        get area(){
            return this.width * this.height;
        }
    
        toString(){
            return `Figures units: ${this.units} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }

   
    return {
        Rectangle,
        Figure,
        Circle
    }
}

