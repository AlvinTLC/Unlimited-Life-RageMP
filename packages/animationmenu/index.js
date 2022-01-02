mp.events.add('sAnimations-stop', (p) => {
    p.setVariable("animation", null);
    p.stopAnimation();
});

mp.events.add('sAnimations-play', (p, dict, name) => {
    p.setVariable("animation", `${dict}:/:${name}`);
    p.playAnimation(dict, name, 1, 47);
});