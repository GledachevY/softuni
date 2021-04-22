function createAssemblyLine(){

    let obj =
    {
        hasClima: function (car) {
            return car.temp = 21,
                car.tempSettings = 21,
                car.adjustTemp = () => {
                    if (car.temp < car.tempSettings) {
                        car.temp++;
                    } else if (car.temp > car.tempSettings) {
                        car.temp--;
                    }
                }

        },

        hasAudio: function (car) {
            car.currentTrack = {
                name,
                artist
            },
                car.nowPlaying = () => {
                    if (!car.artist) {
                        console.log(`Now playing ${car.currentTrack.name} by ${car.currentTrack.artist}`);
                    }
                }
        },

        hasParktronic: function (car) {
            car.checkDistance = function (distance) {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } else if (0.1 < distance && distance < 0.25) {
                    console.log("Beep! Beep!");
                } else if (0.25 < distance && distance < 0.5) {
                    console.log("Beep!");
                }
            }
        }
    };

    return obj;
}


const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);
