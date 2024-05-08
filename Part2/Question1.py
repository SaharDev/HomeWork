import math


def num_len(num: int) -> int:
    return int(math.log(num, 10)) + 1
    # python rounds down when casting from float to int, so 1 added to round up.

def main():
    print(num_len(999))


if __name__ == '__main__':
    main()
