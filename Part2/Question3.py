def is_sorted_polyndrom(s: str) -> bool:
    s = s.lower()
    l, r = 0, len(s) - 1
    last = -1

    while l <= r:
        if s[l] == s[r] and (unicode := ord(s[l])) >= last:
            l += 1
            r -= 1
            last = unicode
        else:
            return False

    return True


def main():
    print(is_sorted_polyndrom('סעס'))


if __name__ == '__main__':
    main()
