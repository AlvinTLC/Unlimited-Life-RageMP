function scaling() {
    const defaultHeight = 1080;
    const currentHeight = window.innerHeight;
    const scaleCoeff = currentHeight / defaultHeight;

    const iphone = document.querySelector('#iphone');
    iphone.style.transform = `scale(${scaleCoeff})`;
}

window.onload = () => {
    scaling();
}

window.onresize = () => {
    scaling();
}