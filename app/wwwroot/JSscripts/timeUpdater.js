function startCountdown(elementId, endDate, updateFrequency) {
    var countDownDate = new Date(endDate).getTime();
    var outputString;
    var updateInterval;

    // atualiza o countdown
    function updateCountdown() {
        var now = new Date().getTime();
        var distance = countDownDate - now;
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

        if (days > 0) {
        outputString = "Faltam " + days + " dias " + hours + " horas " ;
        } else if (hours > 0) {
        outputString = "Faltam " + hours + " horas " + minutes + " min ";
        } else {
        outputString = "Faltam " + minutes + " min " + seconds + " seg";
        }

        document.getElementById(elementId).innerHTML = outputString;

        if (distance < 0) {
            clearInterval(updateInterval);
            document.getElementById(elementId).innerHTML = "ENCERRADO";
        }
    }

    if (updateFrequency > 1000) { // se for para leiloes que demoram mais de uma hora, apenas se atualiza de min em min, em vez de seg em seg
        var now = new Date(),
            secondsRemaining = (60 - now.getSeconds()) * 1000;
            
            setTimeout(function() {
                updateCountdown();
                updateInterval = setInterval(updateCountdown, updateFrequency);
            }, secondsRemaining);
            
    } else {
        updateInterval = setInterval(updateCountdown, updateFrequency);
    }
}