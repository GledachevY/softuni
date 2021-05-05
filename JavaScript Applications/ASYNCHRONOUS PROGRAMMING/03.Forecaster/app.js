function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}

attachEvents();

async function getWeather() {

    const location = document.getElementById('location').value;

    console.log(location);

    const code = await getCode(location);
    const currentWeather = await getConditions(code);
    const upcoming = await getUpcomingForecast(code);

    const currentforecastElement = e('div',{className: 'forecasts'},
    e('span',{className: 'condition Symbol'},getSymbol(currentWeather.forecast.condition)),
    e('span', {className: 'condition'},
    e('span', {className: 'forecast-data'}, currentWeather.name,
    e('span', {className: 'forecast-data'}, `${currentWeather.forecast.low}/${currentWeather.forecast.heigh}`,
    e('span', {className: 'forecast-data'}, currentWeather.forecast.condition)
    ))));

    const forecastElement = document.getElementById('forecast');
    forecastElement.style.display = 'block';
    const elementToPutCurrentForecast = document.getElementById('current')
    elementToPutCurrentForecast.appendChild(currentforecastElement);
}

async function getCode(cityName) {
    const url = 'http://localhost:3030/jsonstore/forecaster/locations';
    const response = await fetch(url);
    const data = await response.json();
    //console.log(data.find(l => l.name.toLowerCase == cityName.toLowerCase()).code);

    return data.find(l => l.name == cityName).code;
}

async function getConditions(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

async function getUpcomingForecast(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;
    const response = await fetch(url);
    const data = await response.json();
    return data;
}


function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}

function getSymbol(weather) {
    switch (weather) {
        case 'Sunny':
            return '☀';
        case 'Partly sunny':
            return '⛅';
        case 'Overcast':
            return '☁';
        case 'Rain':
            return '☂';
        case 'Degrees':
            return '°';
    }
}