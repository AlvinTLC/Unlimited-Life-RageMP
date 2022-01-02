var mysql = require('mysql2');

module.exports = {
    Handle: null,
    Connect: function(callback) {
        this.Handle = mysql.createPool({
            connectionLimit: 100,
            host: 'localhost',
            user: 'root',
            password: 'cYFzBvHXfONWTkyc1TqIDd1V7dLY1ZcmqexLTzJaRzUEYbwlMyDgeXVdqMOl7PFgDDyfpUb9uVQWsNbwZLkiwCVxhpPsmxvPKTG',
            database: 'project',
            debug: false,
        });
        callback();
    },
    Characters: {
        getSqlIdByName: (name, callback) => {
            DB.Handle.query("SELECT id FROM characters WHERE name=?", [name], (e, result) => {
                if (result.length > 0) callback(result[0].id);
                else callback(0);
            });
        }
    }
};

