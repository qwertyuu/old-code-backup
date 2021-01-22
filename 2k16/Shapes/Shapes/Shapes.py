def rect(x, y, width, height):
    print(
        '\n' * y +
        ' ' * x + 
        '#' * width +
        '\n' +
        (' ' * x + 
        '#' + (' ' * (width - 2)) + '#\n') * (height - 2) +
        ' ' * x + 
        '#' * width
    )
rect(10, 10, 5, 3)
raw_input()