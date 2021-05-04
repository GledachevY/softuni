function myFunc(libary, orders) {
    const resultArr = [];

    for (let order of orders) {
        let current = Object.assign({}, order.template);
        for (let part of order.parts) {
            current[part] = libary[part];
        }
        resultArr.push(current);
    }

    return resultArr;
}




const library = {
    print: function () {
        console.log(`${this.name} is printing a page`);
    },
    scan: function () {
        console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
        console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
};
const orders = [
    {
        template: { name: 'ACME Printer' },
        parts: ['print']
    },
    {
        template: { name: 'Initech Scanner' },
        parts: ['scan']
    },
    {
        template: { name: 'ComTron Copier' },
        parts: ['scan', 'print']
    },
    {
        template: { name: 'BoomBox Stereo' },
        parts: ['play']
    },
];
const products = myFunc(library, orders);
console.log(products);

