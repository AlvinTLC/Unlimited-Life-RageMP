var lockOpen = {
	status: false,
	name: [],
	lock(status, names) {
		if (this.name.length < 2) {
			this.status = status;
			mp.trigger(`changeChatActivate`, !status);
		}
		if (status && !this.name.includes(names)) this.name.push(names);
		else if (!status && this.name.includes(names)) this.name.splice(this.name.indexOf(names), 1);
	}
}

/*
 * var lockOpen = {
	name: [],
	lock(status, names) {
		if (status && !this.name.includes(names)) this.name.push(names);
		else if (this.name.includes(names)) this.name.splice(names, 1);

		if (status && !this.name.includes(names)) this.name.push(names);
		else if (this.name.includes(names)) {
			this.name.splice(this.name.indexOf(names), 1);
			nError("Удалено: " + this.name.length);
		}
	}
}*/
