/**
 * Created by Ed on 20-Jan-16.
 */
function main(input) {
    var players = [];
    for (var i = 0; i < input.length; i++) {
        var tokens = /(.+)\s*vs\.\s*(.+)\s*:\s*(.*)/.exec(input[i]),
            fName = tokens[1].trim().replace(/\s+/g, ' '),
            sName = tokens[2].trim().replace(/\s+/g, ' '),
            scores = tokens[3].trim();
        if (arrayObjectIndexOf(players, fName, 'name') === -1) {
            players.push({
                name: fName,
                matchesWon:0,
                matchesLost:0,
                setsWon:0,
                setsLost:0,
                gamesWon:0,
                gamesLost:0}
            );
        }

        if (arrayObjectIndexOf(players, sName, 'name') === -1) {
            players.push({
                name: sName,
                matchesWon:0,
                matchesLost:0,
                setsWon:0,
                setsLost:0,
                gamesWon:0,
                gamesLost:0}
            );
        }

        var setsWonOne = 0,
            setsWonTwo = 0;

        scores = scores.split(/\s+/);
        for (var j = 0; j < scores.length; j++) {
            var set = scores[j].split('-'),
                s1 = Number(set[0]),
                s2 = Number(set[1]);

            players[arrayObjectIndexOf(players, fName, 'name')].gamesWon+=s1;
            players[arrayObjectIndexOf(players, sName, 'name')].gamesWon+=s2;

            players[arrayObjectIndexOf(players, fName, 'name')].gamesLost+=s2;
            players[arrayObjectIndexOf(players, sName, 'name')].gamesLost+=s1;
            if (s1 > s2) {
                setsWonOne++;
                players[arrayObjectIndexOf(players, fName, 'name')].setsWon++;
                players[arrayObjectIndexOf(players, sName, 'name')].setsLost++;
            } else if (s2 > s1) {
                setsWonTwo++;
                players[arrayObjectIndexOf(players, fName, 'name')].setsLost++;
                players[arrayObjectIndexOf(players, sName, 'name')].setsWon++;
            }
        }
        if (setsWonOne > setsWonTwo) {
            players[arrayObjectIndexOf(players, fName, 'name')].matchesWon++;
            players[arrayObjectIndexOf(players, sName, 'name')].matchesLost++;
        } else if (setsWonOne < setsWonTwo) {
            players[arrayObjectIndexOf(players, sName, 'name')].matchesWon++;
            players[arrayObjectIndexOf(players, fName, 'name')].matchesLost++;
        }
    }

    //players.sort(sortArrayOfObjectsByValue);

        players.sort(function(a, b) {

            if(a.matchesWon < b.matchesWon){
                return 1;
            }
            else if(a.matchesWon > b.matchesWon){
                return -1;
            }
            else {
                if(a.setsWon < b.setsWon) {
                    return 1;
                }
                else if(a.setsWon > b.setsWon) {
                    return -1;
                }
                else {
                    if(a.gamesWon < b.gamesWon) {
                        return 1;
                    }
                    else if(a.gamesWon > b.gamesWon) {
                        return -1;
                    }
                    else {
                        return a.name.localeCompare(b.name);
                    }
                }
            }
        });


    console.log(JSON.stringify(players));

    function arrayObjectIndexOf(myArray, searchTerm, property) {
        for(var i = 0, len = myArray.length; i < len; i++) {
            if (myArray[i][property] === searchTerm) return i;
        }
        return -1;
    }

    function sortArrayOfObjectsByValue(a,b) {
        if (a.name < b.name)
            return -1;
        else if (a.name > b.name)
            return 1;
        else
            return 0;
    }
}

main([
'Novak Djokovic vs. Roger Federer : 6-3 6-3',
'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
'Andy Murray vs. David     Ferrer : 6-4 7-6',
'Tomas   Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
'Pete Sampras vs. Andre Agassi : 2-1',
'Boris Beckervs.Andre        Agassi:2-1',

]);