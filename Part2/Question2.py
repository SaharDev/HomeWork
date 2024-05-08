def pythagorean_triplet_by_sum(sum: int) -> None:
    # Brute Force Solution
    for a in range(sum // 3):
        # Due to: 0 < a < b < c, a+b+c = sum the max value of a is close to 1/3 of sum.
        b = a + 1
        while a < b < (c := sum - a - b):
            if a * a + b * b == c * c:
                print(f'{a} < {b} < {c}')
            b += 1


# Mathematical Try, O(n) time complexity
# Not working when the m or n is not integers, which in some inputs can skip on some triplets.
# def pythagorean_triplet_by_sum(sum: int) -> None:
#     if sum % 2 == 1:
#         return
#
#     ls = get_all_divisors(sum)
#     all_triples = set()
#     for m in range(2, int(((sum / 2) ** 0.5) + 1)):  # O(sqrt(n))
#         for multiplier in ls:  # O(sqrt(n))
#             n = ((sum / multiplier) / (2 * m)) - m
#
#             if n >= m:
#                 continue
#
#             a = int(multiplier * (m ** 2 - n ** 2))
#             b = int(multiplier * (2 * m * n))
#             c = int(multiplier * (m ** 2 + n ** 2))
#
#             if (((a, b, c) not in all_triples) and
#                     0 < a < b < c and
#                     a + b + c == sum and
#                     a * a + b * b == c * c):
#                 print(f'{a} < {b} < {c}')
#                 all_triples.add((a, b, c))
#
#     return all_triples
#
#
# # Total time complexity -> O(n)
#
# def get_all_divisors(num: int) -> set:  # O(sqrt(n))
#
#     count = 1
#     res = list()
#
#     while count * count <= num:
#         if num % count == 0:
#             res.append(count)
#             res.append(num / count)
#         count += 1
#     return res

def main():
    x = 60
    pythagorean_triplet_by_sum(x)


if __name__ == '__main__':
    main()
