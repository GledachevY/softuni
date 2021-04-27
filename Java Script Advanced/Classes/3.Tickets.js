function solve (ticketArr, sortCriteria){
    // class Ticket{
    //     constructor(){
    //         this._destination;
    //         this._price;
    //         this._departured;
    //     }

    //     get destination {
    //         return this._destination;
    //     }
    //     set destination(value){

    //     }
    // }

    const outputArr = [];

    for(let ticket of ticketArr){
        const cmd = ticket.split('|');
        const destination = cmd[0];
        const price = cmd[1];
        const status = cmd[2];

        outputArr.push({destination, price, status});
    }

    function sort(){
        const result = outputArr.sort((a,b) => b[sortCriteria] - a[sortCriteria]);
        return result
    }

    const asd = sort();

    console.log(asd);
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);