function solve(){
    const proto = {};
    const instance = Object.create(proto);

    instance.extend = function(template){
        Object.entries(template).forEach(([key,value])=> {
            if(typeof value === 'function'){
                proto[key] = value;
            }else{
                instance[key] = value;
            }
        });
    }

    return instance;
}