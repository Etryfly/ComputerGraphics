#include <windows.h> 
#include <GL/glut.h>  
#include <SOIL.h>
#include <iostream>

char title[] = "8";
GLfloat light1_diffuse[] = { 1, 1, 1 };
float pos[4] = { 0,0,-3,0 };
float lightPos[4] = { -3,-5,-3,0.5f };
int width, height;
GLubyte* image = SOIL_load_image("coal.jpg", &width, &height, 0, SOIL_LOAD_RGB);
bool isTextureEnable = true;
float angle = 0;

void processKeys(int key, int x, int y) {

    if (key == GLUT_KEY_RIGHT) {
        pos[0] -= 1;
    }

    if (key == GLUT_KEY_LEFT) {
        pos[0] += 1;
    }

    if (key == GLUT_KEY_UP) {
        pos[1] -= 1;
    }

    if (key == GLUT_KEY_DOWN) {
        pos[1] += 1;
    }

    if (key == GLUT_KEY_F1) {
        lightPos[1] +=5;
    }


    if (key == GLUT_KEY_F2) {
        lightPos[1] -= 5;
    }

    if (key == GLUT_KEY_F3) {
        light1_diffuse[0] += 0.1f;
    }

    if (key == GLUT_KEY_F4) {
        light1_diffuse[0] -= 0.1f;
    }

    if (key == GLUT_KEY_F5) {
        isTextureEnable = !isTextureEnable;
    }
    if (key == GLUT_KEY_F6) {
        angle += 5;
    }

   
    glutPostRedisplay();
}


void initGL() {
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
    glClearDepth(1.0f);                 
    glutSpecialFunc(processKeys);
  //  glutMotionFunc(mouseMove);
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);    
    glShadeModel(GL_SMOOTH);  
    glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);  
}



void display() {
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glMatrixMode(GL_MODELVIEW);   
    glOrtho(-2.0, 2.0, -2.0, 2.0, -1.5, 1.5);
    
    glEnable(GL_LIGHTING);
    glLoadIdentity();        

    glEnable(GL_LIGHT0);
    

    glLightfv(GL_LIGHT0, GL_POSITION, lightPos);
    glLightfv(GL_LIGHT0, GL_DIFFUSE, light1_diffuse);

    GLfloat light2_diffuse[] = { 1, 0.5, 1 };
    
    float lightPos2[4] = { -3,5,-3,0.5f };

    float ambient[4] = { 1, 1, 1, 1 };

    glEnable(GL_LIGHT1);



    glLightfv(GL_LIGHT1, GL_POSITION, lightPos2);
    glLightfv(GL_LIGHT1, GL_DIFFUSE, light2_diffuse);

    glLightModelfv(GL_LIGHT_MODEL_AMBIENT, ambient);

    glTranslatef(pos[0], pos[1], pos[2]);
   

    glTranslatef(1.5f, 0.0f, -7.0f);
    glRotatef(40, 0.0, 1.0, 0.0);
    glRotatef(33, 1.0, 0.0, 0.0);

    glRotatef(angle, 0, 1.0, 0);

    if (isTextureEnable) {
        glEnable(GL_TEXTURE_2D);
    }
    else {
        glDisable(GL_TEXTURE_2D);
    }
    GLuint texture;
    glGenTextures(1, &texture);
    glBindTexture(GL_TEXTURE_2D, texture);
    

    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);

   
  
    
    glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, image);
    gluBuild2DMipmaps(GL_TEXTURE_2D, 3,
       width, height,
       GL_RGB, GL_UNSIGNED_BYTE, image);
    //glGenerateMipmap(GL_TEXTURE_2D);
    
    glBegin(GL_QUADS);

    //glColor3f(1.0f, 1.0f, 1.0f);
    glTexCoord2f(0, 0); glVertex3f(-1, 2, 0);
    glTexCoord2f(0, 1); glVertex3f(0, 1, 1);
    glTexCoord2f(1, 1); glVertex3f(1, 0, 1);
    glTexCoord2f(1, 0); glVertex3f(2, 0, 0);


   // glColor3f(0.0f, 1.0f, 0.0f);
    glTexCoord2f(0, 0); glVertex3f(1, 0, 1);
    glTexCoord2f(0, 1); glVertex3f(2, 0, 0);
   glTexCoord2f(1, 1); glVertex3f(-1, -2, 0);
   glTexCoord2f(1, 0); glVertex3f(0, -1, 1);


   // glColor3f(0.0f, 0.0f, 1.0f);
    glTexCoord2f(0, 0); glVertex3f(-1, -2, 0);
    glTexCoord2f(0, 1); glVertex3f(0, -1, 1);
    glTexCoord2f(1, 1); glVertex3f(0, 1, 1);
    glTexCoord2f(1, 0); glVertex3f(-1, 2, 0);
    glEnd();

    glBegin(GL_TRIANGLES);          
      
    glColor3f(1.0f, 0.0f, 1.0f);   
    glTexCoord2f(0, 0); glTexCoord2f(0.0f, 0.0f); glVertex3f(-1, 2, 0);
    glTexCoord2f(0, 1); glTexCoord2f(0.0f, 1.0f); glVertex3f(2, 0, 0);
    glTexCoord2f(1, 1); glTexCoord2f(1.0f, 0.0f); glVertex3f(-1, -2, 0);
    
    glColor3f(1.0f, 1.0f, 1.0f);    
    glTexCoord2f(0, 0); glVertex3f(0, 1, 1);
    glTexCoord2f(0, 1); glVertex3f(1, 0, 1);
    glTexCoord2f(1, 1); glVertex3f(0, -1, 1);
   
    glEnd();   
   


    glTranslatef(-1.5f, -  2.0f, -6.0f);

    GLUquadricObj* obj = gluNewQuadric();
    gluQuadricDrawStyle(obj, GLU_FILL);
      
    gluQuadricDrawStyle(obj, GLU_LINE);
    gluQuadricNormals(obj, GLU_SMOOTH);
    gluQuadricTexture(obj, GL_TRUE);
    gluCylinder(obj, 1, 1, 2, 5, 1);
    gluDeleteQuadric(obj);

    glDisable(GL_TEXTURE_2D);
   
    glLoadIdentity();                  
   

    glutSwapBuffers(); 

  

    
   // glutTimerFunc(1, timer, 0);
}


void reshape(GLsizei width, GLsizei height) {  
    if (height == 0) height = 1;                
    GLfloat aspect = (GLfloat)width / (GLfloat)height;

    glViewport(0, 0, width, height);

    glMatrixMode(GL_PROJECTION);  
    glLoadIdentity();            
    gluPerspective(45.0f, aspect, 0.1f, 100.0f);
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);          
    glutInitDisplayMode(GLUT_DOUBLE); 
    glutInitWindowSize(800, 600);  
    glutInitWindowPosition(50, 50);
    glutCreateWindow(title);          
    glutDisplayFunc(display);      
    glutReshapeFunc(reshape);      
    glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);
    initGL();                       

    
    glutMainLoop();                
    return 0;
}