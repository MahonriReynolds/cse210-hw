public class Tile
{
    private int _xCoord;
    private int _width;
    private char[,] _content;

    public Tile(int x, int verdure)
    {
        this._xCoord = x;
        this._width = 30;
        this._content = new char[this._width, this._width];

        Random random = new Random();

        int groundLevel = 20;
        for (int j = 0; j < this._width; j++)
        {
            for (int i = 0; i < groundLevel; i++)
            {
                this._content[i, j] = ' ';
            }

            this._content[groundLevel, j] = '_';
        }

        for (int i = groundLevel + 1; i < this._width; i++)
        {
            for (int j = 0; j < this._width; j++)
            {
                double prob = random.NextDouble();
                if (prob < 0.1)
                {
                    this._content[i, j] = '_';
                }
                else if (prob > 0.99)
                {
                    this._content[i, j] = 'X';
                }
                else
                {
                    this._content[i, j] = ' ';
                }
            }
        }

        this.Decorate(random, verdure);
    }

    private void Decorate(Random random, int verdure)
    {
        List<string[]> trees = new List<string[]>
        {
            
            //Slightly modified from https://ascii.co.uk/art/tree
            new string[]
            {
                @"           .        ;;",
                @",         ,         ;",
                @" :       ;        ;%'   .",
                @"  %;    ;       ; %;  ,",
                @"  ;%;  %         %;;  %",
                @"    %;%;    ,     %;  %'",
                @"     %;      %     % ;;",
                @".     ;%    %'     `;%;",
                @";%.    ;. %@;   %; ;@%",
                @"   `@%:.:;%.    ;@@%;'",
                @"        @%. :%@@%;",
                @"         %@bd%%:;",
                @"           #@%;;",
                @"           %@@;  . '",
                @"           %@@(.,'",
                @"        .. %@@;",
                @"         `)@@@;",
                @"          %@@@@.;",
                @"         ;%@@@@;."

            },
            new string[]
            {
                @"      '.,",
                @"        'b      *",
                @"         '$    #.",
                @"          $:   #:",
                @"          *#  @):",
                @"          :@,@):   ,.**:'",
                @",         :@@*: ..**'",
                @" '#o.    .:(@'.@*''",
                @"    'bq,..:,@@*'   ,*",
                @"    ,p$q8,:@)@' .p*'",
                @"   '    ';@@p-;*'",
                @"         @@'.'",
                @"        :@@@.",
                @"       .:@@@.",
                @"     .::(@@@@"
            },
            new string[]
            {
                @"     ccee88oo",
                @"  C8O8O8Q8PoOb o8oo",
                @" dOB69QO8PdUOpugoO9bD",
                @"CgggbU8OU qOp qOdoUOdcb",
                @"    6OuU  /p u gcoUodpP",
                @"      \@@@/  /douUP",
                @"        \@@////",
                @"         @@@/\",
                @"         @@@\/",
                @"         @@@@|",
                @"        /@@@@@\"
            },
            new string[]
            {
                @"       oopxxx",
                @"   oxoxoo xxxooxoo",
                @" ooxoxo ooxooxoxooo",
                @"oooo xxoxoopooo ooox",
                @"oxo o oxoxoxxxo@@oxo",
                @" oxo xooxoooo@@ ooo",
                @"   ooo\oo\  /@/o",
                @"       \@@\/@/",
                @"        |@|./",
                @"        |@@|",
                @"        |@@|",
                @"        |@@|",
                @"        |@@@",
                @"      _{@@@@@_"
            },
            new string[]
            {

                @"        # #### ####",
                @"      ### \/#|### |/####",
                @"     ##\/#/ \||/##/_/##/_#",
                @"   ###  \/###|/ \/ # ###",
                @" ##_\_#\_\## |.#/###_/_####",
                @"##.####.#.\.#|./..#### ##/##",
                @" __#_--###@@@|{,###---###-~",
                @"           @@}{",
                @"            @@{",
                @"            @@@",
                @"            @@@",
                @"       ,.-=-@@@@-^-._",
                @"             }"
            },
            new string[]
            {
                @"         &&& &&  & &&",
                @"     & &\/&\|& ()|/ @, &",
                @"     &/(/&/&||/& /_/)_&_&",
                @"  &() \/@@()|/&\/.@@; &()",
                @" &_\_&_\.|&.|&&/&__%_/_ &&",
                @"...@@@.&|.@@./&@@.%.()./&&",
                @"()&_--()&\&@@&&-&&--%--()~",
                @"    &&     \@@|",
                @"           |@@/",
                @"           /@@/",
                @"           \@@@",
                @"     , -=-~@@@@@-._",
                @"            `"

            },
            new string[]
            {
                @"                 ___",
                @"           _,-'''...''''--.",
                @"        ,-'..........__,,--.\",
                @"      ,'....__,--''''dF......)",
                @"     /....-'Hb_,--''dF....../",
                @"   ,'......._Hb.___dF'-._,-'",
                @" ,'......_,-''''...''--..__",
                @"(.....,-'...................",
                @" ._,'....._..._.............;",
                @"  ,'.....,'.-'Hb-.___..._,-'",
                @"  \....,''Hb.-'HH-.dHF'",
                @"   --'   'Hb..HH..dF'",
                @"           'Hb.HH.dF",
                @"            'HbHHdF",
                @"             |HHHF",
                @"             |HHH|",
                @"             |HHH|",
                @"             |HHH|",
                @"             |HHH|",
                @"             dHHHb",
                @"           .dFd|bHb.",
                @"         .dHFdH|HbTHb.",
                @"      ,dHHFdHH|HHhoHHb."
            },
            new string[]
            {
                @"                 ___",
                @"           _,-'''...''''--.",
                @"        ,-'..........__,,--.\",
                @"      ,'....__,--''''dF......)",
                @"     /....-'Hb_,--''dF....../",
                @"   ,'......._Hb.___dF'-._,-'",
                @" ,'......_,-''''...''--..__",
                @"(.....,-'...................",
                @" ._,'....._..._.............;",
                @"  __,---,__,'.-'Hb-.___..._,-'",
                @" /.....''Hb.-'HH-.dHF'",
                @"|........'Hb..HH..dF'",
                @" \_.......__Hb.HH.dF",
                @"   '__\HH\  'HbHHdF",
                @"        \HH\ |HHHF",
                @"          \HH|HHH|",
                @"            \|HHH|",
                @"             |HHH|",
                @"             |HHH|",
                @"             dHHHb",
                @"           .dFd|bHb.",
                @"         .dHFdH|HbTHb.",
                @"      ,dHHFdHH|HHhoHHb."
            },
            new string[]
            {
                @"                 ___",
                @"           _,-'''...''''--.",
                @"        ,-'..........__,,--.\",
                @"      ,'....__,--''''dF......)",
                @"     /....-'Hb_,--''dF....../",
                @"   ,'......._Hb.___dF'-._,-'",
                @" ,'......_,-''''...''--..__",
                @"(.....,-'...................",
                @" ._,'....._..._.............;",
                @"  __,---,__,'.-'H_-.___..._,-'",
                @" /.....''Hb.-'HH|.......'-.  ",
                @"|........'Hb..HH|..........'.",
                @" \_.......__Hb.HH'--,__.....|",
                @"   '__\HH\  'HbHHdF  HH\___/",
                @"        \HH\ |HHHF  /HHH/",
                @"          \HH|HHH| |HHH|",
                @"            \|HHH|/HHH/",
                @"             |HHH|HH/",
                @"             |HHH|H/",
                @"             dHHHb/",
                @"           .dFFd|bHb.",
                @"        .dFHFdH|HbTHbb.",
                @"     ,dHHFdHH|HHhoHHbbb."
            }
        };

        if (verdure == -1)
        {
            //Slightly modified from https://ascii.co.uk/art/cabins
            string[] cabin =
            {
                @"                              ",
                @" Navigate --------- <- Λ V -> ",
                @" Dash Forwards ---- Tab       ",
                @" Dash Backwards --- Backspace ",
                @" Pause game ------- Escape    ",
                @"   /\                         ",
                @"  /%%\  /\                    ",
                @" /%%%%\/%%\                   ",
                @" /%%%%/%%%%\    ,   /\        ",
                @"/% @@  /\%%\/\ ,~, /%%\       ",
                @"%/\%  @@ \%/%%\~~~/%%%%\      ",
                @"/%%\%%\ @@ %(%%\~~/%%%%\      ",
                @"%%%%\%%\ @@ %%%\~/%%%%%%\     ",
                @"\%%%\%%\%[_]%%%%/%%%%%%%%\    ",
                @"%\_______[_]________%%%%%\    ",
                @"%%\ _-       _-  _- \%%%%%\   ",
                @"%%%\______-__________\''','   ",
                @"%%%\__===______====_]|' ,~,   ",
                @"%%%%\_|_|______|  |_]| ,~~~,  ",
                @"%%%%%\_________|- |_]|,~~~~~, ",
                @"%%%%%\___#__#__|__|_],~~~~~~~,",
                @"%%%%%%'''\/'''/  \'  ,~~;~~,~,",
                @"%%%%%%%\   _-           '|' _ ",
                @"%%%%%%%\       _       ~'''~  ",
                @"%%%%#%%#\ _      _- _   _    _",
                @"'''''\/''   _-          _-    ",
                @"_      _        _           _ ",
                @" _          _          _      ",
                @"    _                _      _ ",
                @"  _       _     _     _      _",
            };

            for (int i = 0; i < this._width; i++)
            {
                for (int j = 0; j < this._width; j++)
                {
                    this._content[i, j] = cabin[i][j];
                }
            }
        }
        else if (verdure == 100)
        {
            string[] finishLine =
            {
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"                              ",
                @"______________________________",
                @"  _     ||  .-..--. _      _  ",
                @"       _|| | ☾ \.--'   _      ",
                @" _      || ||-.|   |          ",
                @"   _    ||_|'-||   |    _    _",
                @" _  _   || '-. |.--' _   _    ",
                @"       _||      _           _ ",
                @" _      ||  _          _      ",
                @"    _   ||           _      _ ",
                @"  _     ||_     _     _      _",
            };

            for (int i = 0; i < this._width; i++)
            {
                for (int j = 0; j < this._width; j++)
                {
                    this._content[i, j] = finishLine[i][j];
                }
            }
        }

        else
        {
            int targetIndex = verdure * trees.Count / 100 - 1;
            int startIndex = targetIndex - 1 > 0 ? targetIndex : 0;
            int endIndex = targetIndex + 2 < trees.Count - 1 ? targetIndex + 2 : trees.Count - 1;

            if (startIndex <= endIndex)
            {
                int numTrees = Math.Min(targetIndex + 1, 3);
                if (trees.Count - targetIndex <= 3) 
                {
                    numTrees = Math.Min(numTrees, 2);
                }
                if (random.NextDouble() < 0.5 && numTrees > 0)
                {
                    numTrees--;
                }

                List<Tuple<int, int, string[]>> treeInfo = new List<Tuple<int, int, string[]>>();

                for (int i = 0; i < numTrees; i++)
                {
                    int randomIndex = random.Next(startIndex, endIndex);
                    string[] selectedTree = trees[randomIndex];

                    int maxTreeWidth = selectedTree.Max(line => line.Length);
                    int maxTreeHeight = selectedTree.Length;

                    int startX = random.Next(maxTreeWidth / 2, _width - maxTreeWidth / 2);
                    int startY = random.Next(21, 26) - maxTreeHeight + 1;

                    treeInfo.Add(Tuple.Create(startX, startY, selectedTree));
                }

                treeInfo.Sort((t1, t2) =>
                {
                    int bottomRow1 = t1.Item2 + t1.Item3.Length - 1;
                    int bottomRow2 = t2.Item2 + t2.Item3.Length - 1;
                    return bottomRow1.CompareTo(bottomRow2);
                });

                foreach (var info in treeInfo)
                {
                    int startX = info.Item1;
                    int startY = info.Item2;
                    string[] selectedTree = info.Item3;

                    int maxStringLength = selectedTree.Max(line => line.Length);
                    int startCol = startX - (maxStringLength / 2);

                    int rowsToCopy = Math.Min(selectedTree.Length, _width - startY);

                    for (int i = 0; i < rowsToCopy; i++)
                    {
                        for (int j = 0; j < selectedTree[i].Length; j++)
                        {
                            int targetRow = startY + i;
                            int targetCol = startCol + j;

                            if (targetRow >= 0 && targetRow < _width && targetCol >= 0 && targetCol < _width)
                            {
                                if (selectedTree[i][j] != ' ')
                                {
                                    _content[targetRow, targetCol] = selectedTree[i][j];
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public Tuple<int, char[,]> Print()
    {
        return Tuple.Create(this._xCoord, this._content);
    }
}
