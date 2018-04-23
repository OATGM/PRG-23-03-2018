/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package thegame;

import java.util.Scanner;

/**
 *
 * @author superuser
 */
public class TheGame {

    public static void main(String[] args) {
        int pohyb;
        Scanner sc = new Scanner(System.in, "Windows-1250");
        int xKot = 3;
        int yKot = 3;
        int xMys = 5;
        int yMys = 5;
        int score = 0;
        Boolean jeMys = false;
        Boolean jeKot = false;
        Boolean hrajeSe = true;

        System.out.println("Kde bude myš? - 18 na 8 políček");
        System.out.println("y: ");
        yMys = Integer.parseInt(sc.nextLine());
        System.out.println("x: ");
        xMys = Integer.parseInt(sc.nextLine());
        System.out.println("Kde bude kočka?");
        System.out.println("y: ");
        yKot = Integer.parseInt(sc.nextLine());
        System.out.println("x: ");
        xKot = Integer.parseInt(sc.nextLine());

        while (hrajeSe) {

            for (int i = 0; i < 10; i++) {
                if (yMys == i) {
                    jeMys = true;
                } else {
                    jeMys = false;
                }

                if (yKot == i) {
                    jeKot = true;
                } else {
                    jeKot = false;
                }

                if (i == 0) {
                    for (int k = 0; k < 20; k++) {
                        System.out.print("×");
                        if (k == 19) {
                            System.out.println("");
                        }
                    }
                }
                if (i > 0) {
                    if (i < 9) {
                        for (int k = 0; k <= 20; k++) {
                            if (k == 0) {
                                System.out.print("×");
                            }
                            if (k > 0) {
                                if (k < 19) {
                                    if (!jeMys) {
                                        if (!jeKot) {
                                            System.out.print(" ");
                                        }
                                    }
                                    if (jeMys) {
                                        if (k < xMys) {
                                            if (!jeKot) {
                                                System.out.print(" ");
                                            }
                                            if (jeKot) {
                                                if (k == xKot) {
                                                    System.out.print("O");
                                                } else {
                                                    System.out.print(" ");
                                                }
                                            }
                                        }
                                        if (k == xMys) {
                                            if (xMys != xKot) {
                                                System.out.print("X");
                                            }
                                        }
                                        if (k > xMys) {
                                            if (!jeKot) {
                                                System.out.print(" ");
                                            }
                                            if (jeKot) {
                                                if (k == xKot) {
                                                    System.out.print("O");
                                                } else {
                                                    System.out.print(" ");
                                                }
                                            }
                                        }
                                    }

                                    if (jeKot) {
                                        if (k < xKot) {
                                            if (!jeMys) {
                                                System.out.print(" ");
                                            }
                                        }
                                        if (k == xKot) {
                                            if (!jeMys) {
                                                System.out.print("O");
                                            }
                                        }
                                        if (k > xKot) {
                                            if (!jeMys) {
                                                System.out.print(" ");
                                            }
                                        }
                                    }

                                }
                            }
                            if (k == 19) {
                                System.out.println("×");
                            }
                        }
                    }
                }
                if (i == 9) {
                    for (int k = 0; k < 20; k++) {
                        System.out.print("×");
                    }
                }

            }
            System.out.println("");
            System.out.println("Toje score je: " + score);
            score++;

            System.out.println("Na řadě je Myš!");
            for (int round = 0; round < 1;) {
                pohyb = Integer.parseInt(sc.nextLine());
                if (pohyb == 8) {
                    yMys--;
                    round++;
                }
                if (pohyb == 2) {
                    yMys++;
                    round++;
                }
                if (pohyb == 4) {
                    xMys--;
                    round++;
                }
                if (pohyb == 6) {
                    xMys++;
                    round++;
                }
                if (pohyb == 7) {
                    xMys--;
                    yMys--;
                    round++;
                }
                if (pohyb == 9) {
                    xMys++;
                    yMys--;
                    round++;
                }
                if (pohyb == 1) {
                    xMys--;
                    yMys++;
                    round++;
                }
                if (pohyb == 3) {
                    xMys++;
                    yMys++;
                    round++;
                }
                if (pohyb == 5) {
                    hrajeSe = false;
                    round++;
                }

                if (yMys <= 0) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    yMys++;
                }
                if (yMys >= 9) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    yMys--;
                }
                if (xMys <= 0) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    xMys++;
                }
                if (xMys >= 19) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    xMys--;
                }
            }

            System.out.println("Na řadě je Kočka!");
            for (int round = 0; round < 1;) {
                pohyb = Integer.parseInt(sc.nextLine());
                if (pohyb == 8) {
                    yKot--;
                    round++;
                }
                if (pohyb == 2) {
                    yKot++;
                    round++;
                }
                if (pohyb == 4) {
                    xKot--;
                    round++;
                }
                if (pohyb == 6) {
                    xKot++;
                    round++;
                }
                if (pohyb == 7) {
                    xKot--;
                    yKot--;
                    round++;
                }
                if (pohyb == 9) {
                    xKot++;
                    yKot--;
                    round++;
                }
                if (pohyb == 1) {
                    xKot--;
                    yKot++;
                    round++;
                }
                if (pohyb == 3) {
                    xKot++;
                    yKot++;
                    round++;
                }
                if (pohyb == 5) {
                    hrajeSe = false;
                    round++;
                }

                if (yKot <= 0) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    yKot++;
                    if (pohyb == 7) {
                        xKot++;
                    }
                    if (pohyb == 9) {
                        xKot--;
                    }
                }
                if (yKot >= 9) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    yKot--;
                    if (pohyb == 1) {
                        xMys++;
                    }
                    if (pohyb == 3) {
                        xMys--;
                    }
                }
                if (xMys <= 0) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    xKot++;
                    if (pohyb == 7) {
                        yKot++;
                    }
                    if (pohyb == 1) {
                        xKot++;
                    }
                }
                if (xKot >= 19) {
                    System.out.println("Tam nesmíš!");
                    round--;
                    xKot--;
                    if (pohyb == 9) {
                        yKot++;
                    }
                    if (pohyb == 3) {
                        yKot--;
                    }
                }
            }

            if (yKot == yMys) {
                if (xKot == xMys) {
                    hrajeSe = false;
                    System.out.println("Kočka tě snědla, prohrál jsi!");
                }
            }
        }
    }

}
