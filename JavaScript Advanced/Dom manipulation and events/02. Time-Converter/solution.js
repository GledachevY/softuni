function attachEventsListeners() {

    const main = document.querySelector('main').addEventListener('click', onClick);

    function onClick(event) {

        const days = document.getElementById('days');
        const hours = document.getElementById('hours');
        const minutes = document.getElementById('minutes');
        const seconds = document.getElementById('seconds');

        if (event.target === document.querySelector('#daysBtn')) {

            hours.value = 0;
            minutes.value = 0;
            seconds.value = 0;
            hours.value = Number(days.value) * 24;
            minutes.value = Number(hours.value) * 60;
            seconds.value = Number(minutes.value) * 60;

        } else if (event.target === document.querySelector('#hoursBtn')){

            days.value = 0;
            minutes.value = 0;
            seconds.value = 0;
            days.value = Math.floor(Number(hours.value) / 24);
            minutes.value = Number(hours.value) * 60;
            seconds.value = Number(minutes.value) * 60;

        } else if (event.target === document.querySelector('#minutesBtn')){

            days.value = 0;
            hours.value = 0;
            seconds.value = 0;
            hours.value = Math.floor(Number(minutes.value) / 60);
            days.value = Math.floor(Number(hours.value) / 24);
            seconds.value = Number(minutes.value) * 60;

        } else if (event.target === document.querySelector('#secondsBtn')){

            days.value = 0;
            minutes.value = 0;
            hours.value = 0;
            minutes.value = Math.floor(Number(seconds.value) / 60);
            hours.value = Math.floor(Number(minutes.value) / 60);
            days.value = Math.floor(Number(hours.value) / 24);

        }
    }

}