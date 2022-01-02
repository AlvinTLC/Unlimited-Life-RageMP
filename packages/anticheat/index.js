mp.events.add('server:CheatDetection', (player,flag) => {
    if(flag=='Unallowed Weapon') {
      player.ban()
    }
	mp.players.broadcast('!{#ff0000}[AntiCheat] Detected ' + flag + ' from ' + player.name)
    console.log(`Detected ${flag} from ${player.name} SC: ${player.socialClub}`)
})

mp.events.add("playerWeaponChange", (player) => {
    player.call('client:weaponSwap')
});