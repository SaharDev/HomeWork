import matplotlib.pyplot as plt
import numpy as np


def main():
    lst = []
    avg_y = 1
    avg_x = 0
    pos = 0

    while not lst or lst[-1] != -1:
        lst.append(float(input('Enter a number: ')))
        avg_y += lst[-1]
        avg_x += len(lst) - 1
        pos += 1 if lst[-1] > 0 else 0
    else:
        lst.pop()

    avg_x /= len(lst)
    avg_y /= len(lst)

    print(f'Average: {avg_x}')
    print(f'Positive Count: {pos}')
    print(f'Sorted: {sorted(lst)}')

    # Pearson correlation coefficient
    sum_x = lambda x: x - avg_x
    sum_y = lambda y: y - avg_y

    if len(lst) > 1:
        numerator = sum(sum_x(x + 1) * sum_y(y) for x, y in enumerate(lst))
        denominator = (sum(sum_x(x) * sum_x(x) for x in range(1, len(lst) + 1))
                       * sum(sum_y(y) * sum_y(y) for y in lst)) ** 0.5

        r = (numerator / denominator)
        print(f'Pearson correlation coefficient: {r}')

    # matplotlib

    y_points = np.array(lst)
    x_points = np.array(range(1, len(lst) + 1))

    plt.plot(x_points, y_points, 'o')
    plt.show()


if __name__ == '__main__':
    main()
