import math


def reverse_pi_digits(num: int) -> str:
    return str(math.pi).replace('.', '')[num - 1::-1]


def main():
    print(reverse_pi_digits(5))


if __name__ == '__main__':
    main()
