function attachGradientEvents() {
    const resultDiv = document.getElementById('result');

    const gradientElement = document.getElementById('gradient').addEventListener('mousemove', onMove);
    function onMove(event){

       

        let percent = Math.floor(event.offsetX / event.target.clientWidth * 100);
        
        resultDiv.textContent = `${percent}%`;
    }
}