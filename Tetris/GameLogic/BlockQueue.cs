using System;

namespace Tetris;

public class BlockQueue
{
    readonly Block[] _blocks = new Block[]
    {
        new IBlock(),
        new JBlock(),
        new LBlock(),
        new OBlock(),
        new SBlock(),
        new TBlock(),
        new ZBlock(),
    };

    private readonly Random _random = new();

    public Block NextBlock { get; private set; }

    Block RandomBlock() => _blocks[_random.Next(_blocks.Length)];

    public BlockQueue() => NextBlock = RandomBlock();
    
    public Block GetAndUpdate()
    {
        Block block = NextBlock;
        do
        {
            NextBlock = RandomBlock();
        } while (block.Id == NextBlock.Id);

        return block;
    }
}