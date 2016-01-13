function replaceHTMLTags (input) {
    input = input.split('\n');
    for (var i = 0; i < input.length; i++) {
        if (!input[i].match(/<a href=(.+)>(.*)<\/a>/g)) {
            continue;
        }
        var pattern = /<a href=(.+)>(.*)<\/a>/g;
        var matches = pattern.exec(input[i]);
        var link = matches[1];
        var info = matches[2];
        input[i] = ('[URL href=' + link + ']' + info + '[/URL]');
    }

    console.log(input);
}


replaceHTMLTags('<ul>\n<li>\n<a href=http://softuni.bg>SoftUni</a>\n</li>\n</ul>');