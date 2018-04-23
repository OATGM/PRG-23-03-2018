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
                            if (i == 4) {
                                if (k == 9) {
                                    System.out.print("D");
                                }
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
                                                    System.out.print("K");
                                                } else {
                                                    System.out.print(" ");
                                                }
                                            }
                                        }
                                        if (k == xMys) {
                                            if (xMys != xKot) {
                                                System.out.print("M");
                                            }
                                        }
                                        if (k > xMys) {
                                            if (!jeKot) {
                                                System.out.print(" ");
                                            }
                                            if (jeKot) {
                                                if (k == xKot) {
                                                    System.out.print("K");
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
                                                System.out.print("K");
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
                    yMys = 8;
                }
                if (yMys >= 9) {
                    yMys = 1;
                }
                if (xMys <= 0) {
                    xMys = 18;
                }
                if (xMys >= 19) {
                    xMys = 1;
                }
            }
            if (xMys == 9) {
                if (yMys == 4) {
                    hrajeSe = false;
                    System.out.println("Spadl jsi do díry!");
                }
            }

            if (yKot < yMys) {
                yKot++;
            }
            if (yKot > yMys) {
                yKot--;
            }
            if (yKot == yMys) {
                if (xKot < xMys) {
                    xKot++;
                }
                if (xKot > xMys) {
                    xKot--;
                }
            }
            if (yKot == 4) {
                if (xKot == 9) {
                    hrajeSe = false;
                    System.out.println("Kočka spadla do díry!");
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
