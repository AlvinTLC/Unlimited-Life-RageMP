let positions = [];
let sprunkPointFound = (points) => {
    let sprunkIsNear = false;
    points.forEach(position => {
        if (mp.players.local.dist(position) < 1) {
            sprunkIsNear = true;
        }
    });

    return sprunkIsNear;
};

mp.keys.bind(0x45, true, () => {
	//if (sprunkPointFound(positions)) {
		mp.events.callRemote("sprunk:use");
	//}
});
	
mp.events.add("sprunk:syncPositions", (args) => {

    positions = args;
	
	let json = JSON.stringify(positions);// array with objects x, y, z


    // E key

});