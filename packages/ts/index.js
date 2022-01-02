mp.events.add('Server:Voice:SetRange', (player) => {
	player.setVariable('CLIENT_RANGE', 'Normal');
});

let ranges = ['Normal', 'Weit', 'Leise'];
mp.events.add('Server:Voice:SwitchRange', (player) => {
    let nextRange = undefined;
    let index = ranges.indexOf(player.getVariable('CLIENT_RANGE'));
    if (index === -1 || index === ranges.length - 1) {
        nextRange = ranges[0];
    } else {
        nextRange = ranges[index + 1];
    }
    player.setVariable('CLIENT_RANGE', nextRange);
});
