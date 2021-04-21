function solve(area,vol, input){
    const figures = JSON.parse(input);

    const result = figures.map(f =>({
        area : Math.abs(area.call(f)),
        volume: Math.abs( vol.call(f))
    }));

    return result;
}