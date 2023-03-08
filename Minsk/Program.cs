using Minsk.CodeAnalysis;

while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();

    var parser = new Parser(line);
    var expression = parser.Parse();

    var colour = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.DarkGray;

    PrettyPrint(expression);

    Console.ForegroundColor = colour;

    var lexer = new Lexer(line);
    while (true)
    {
        var token = lexer.NextToken();
        if (token.Kind == SyntaxKind.EndOfFileToken)
            break;
        Console.WriteLine(token);
    }
}

static void PrettyPrint(SyntaxNode node, string indent = "")
{
    Console.Write(indent);
    Console.Write(node.Kind);

    if (node is SyntaxToken t && t.Value != null)
    {
        Console.Write(" ");
        Console.Write(t.Value);
    }

    Console.WriteLine();

    indent += "    ";

    foreach (var child in node.GetChildren())
    {
        PrettyPrint(child, indent);
    }
}