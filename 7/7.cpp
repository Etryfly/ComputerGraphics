
#include <windows.h> 
#include <GL/glut.h>  


char title[] = "7";
float angle =0;

void initGL() {
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
    glClearDepth(1.0f);                 
    glEnable(GL_DEPTH_TEST);  
    glDepthFunc(GL_LEQUAL);    
    glShadeModel(GL_SMOOTH);  
    glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);  
}

void timer(int arg)
{
    angle += 0.1;
    glutPostRedisplay();
    //glutTimerFunc(100, timer, 0);
}


void display() {
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glMatrixMode(GL_MODELVIEW);   
    glOrtho(-2.0, 2.0, -2.0, 2.0, -1.5, 1.5);
    
   
    glLoadIdentity();                  
    glTranslatef(1.5f, 0.0f, -7.0f);
    glRotatef(angle, 0.0, 1.0, 0.0);
    glRotatef(angle, 1.0, 1.0, 0.0);

    glBegin(GL_TRIANGLES);          
      
    glColor3f(1.0f, 0.0f, 0.0f);   
    glVertex3f(-1, 2, 0);
    glVertex3f(2, 0, 0);
    glVertex3f(-1, -2, 0);
  
    glColor3f(1.0f, 1.0f, 1.0f);    
    glVertex3f(0, 1,1);
    glVertex3f(1, 0, 1);
    glVertex3f(0, -1, 1);

    glEnd();   
   

    glBegin(GL_QUADS);

    glColor3f(1.0f, 0.0f,1.0f);
    glVertex3f(-1, 2, 0);
    glVertex3f(0, 1, 1);
    glVertex3f(1, 0, 1);
    glVertex3f(2, 0, 0);


    glColor3f(0.0f, 1.0f, 0.0f);
    glVertex3f(1, 0, 1);
    glVertex3f(2, 0, 0);
    glVertex3f(-1, -2, 0);
    glVertex3f(0, -1, 1);
    

    glColor3f(0.0f, 0.0f, 1.0f);
    glVertex3f(-1, -2, 0);
    glVertex3f(0, -1, 1);
    glVertex3f(0, 1, 1);
    glVertex3f(-1, 2, 0);
    glEnd();

   

    glLoadIdentity();                  
    glTranslatef(-1.5f, 0.0f, -6.0f);

    glutSwapBuffers(); 
    glutTimerFunc(1, timer, 0);
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
    glutInitWindowSize(640, 480);  
    glutInitWindowPosition(50, 50);
    glutCreateWindow(title);          
    glutDisplayFunc(display);      
    glutReshapeFunc(reshape);      
    initGL();                       

    
    glutMainLoop();                
    return 0;
}