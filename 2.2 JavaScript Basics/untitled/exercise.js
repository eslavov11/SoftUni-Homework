/**
 * Created by Ed on 20-Jan-16.
 */
function main(input) {
    var tr = '<tr><td>%d</td><td>%s</td><td>%s</td></tr>',
        index = 0,
        bladeType2 = ['*rap-poker', 'blade', 'quite a blade', 'pants-scraper', 'frog-butcher'];
    console.log('<table border="1">');
    console.log('<thead>');
    console.log('<tr><th colspan="3">Blades</th></tr>');
    console.log('<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>');
    console.log('</thead>');
    console.log('<tbody>');
    for (var i = 0; i < input.length; i++) {
        if (Math.floor(input[i]) <= 10) continue;
        console.log(tr, Math.floor(input[i]), Math.floor(input[i]) > 40 ? 'sword' : 'dagger', bladeType2[Math.floor((input[i]) % 5)]);
    }

    console.log('</tbody>');
    console.log('</table>');
}
main([
    '17.8',
    '19.4',
    '13',
    '55.8',
    '126.96541651',
    '3',

]);