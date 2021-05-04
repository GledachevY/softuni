const createCalculator = require('./7.AddSubtract');

const {expect} = require('chai');


// const obekt = createCalculator();
// obekt.add(4);
// console.log(obekt.value);

describe('Sum func', () => {
    it('are keys prpoer', () => {
        expect(Object.keys(createCalculator())).to.eql(['add', 'subtract', 'get']);
    });
    it('add shold add to sum number', () =>{
        const obekt = createCalculator();
        obekt.add(4);
        expect(obekt.get()).to.equal(4);
    });
    it('add shold add to sum string', () =>{
        const obekt = createCalculator();
        obekt.add('4');
        expect(obekt.get()).to.equal(4);
    });
    it('add shold subtract to sum string', () =>{
        const obekt = createCalculator();
        obekt.subtract('5');
        expect(obekt.get()).to.equal(-5);
    });
    it('add shold add to sum number', () =>{
        const obekt = createCalculator();
        obekt.subtract(2);
        expect(obekt.get()).to.equal(-2);
    });
});
