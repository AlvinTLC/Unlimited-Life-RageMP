mp.world.trafficLights.locked = true;
mp.world.trafficLights.state = 0;
setLights();

function setLights()
{
    mp.world.trafficLights.state = 39;
    setTimeout(function(){
        mp.world.trafficLights.state = 88;
        setTimeout(function(){
            mp.world.trafficLights.state = 49;
            setTimeout(function(){
                mp.world.trafficLights.state = 88;
                setTimeout(function(){
                    mp.world.trafficLights.state = 39;
                    setTimeout(function(){
                        mp.world.trafficLights.state = 0;
                        setTimeout(function(){
                            setLights();
                        }, 50000); // Grünphase West -> Ost
                    }, 4000);  // Grün werden West -> Ost
                }, 8000); // Gelbphase Nord -> Süd
            }, 30000); // Grünphase Nord -> Süd
        }, 4000); // Grün werden Nord -> Süd
    }, 8000); // Gelbphase West -> Ost
};
