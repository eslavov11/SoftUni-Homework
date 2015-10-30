#
# Generated Makefile - do not edit!
#
# Edit the Makefile in the project folder instead (../Makefile). Each target
# has a -pre and a -post target defined where you can add customized code.
#
# This makefile implements configuration specific macros and targets.


# Environment
MKDIR=mkdir
CP=cp
GREP=grep
NM=nm
CCADMIN=CCadmin
RANLIB=ranlib
CC=gcc
CCC=g++
CXX=g++
FC=gfortran
AS=as

# Macros
CND_PLATFORM=MinGW-Windows
CND_DLIB_EXT=dll
CND_CONF=Debug
CND_DISTDIR=dist
CND_BUILDDIR=build

# Include project Makefile
include Makefile

# Object Directory
OBJECTDIR=${CND_BUILDDIR}/${CND_CONF}/${CND_PLATFORM}

# Object Files
OBJECTFILES= \
	${OBJECTDIR}/Problem\ 1.\ Swap\ numbers.o \
	${OBJECTDIR}/Problem\ 2.\ Array\ Print.o \
	${OBJECTDIR}/Problem\ 3.\ Print\ Array\ Reversed.o \
	${OBJECTDIR}/Problem\ 4.\ Print\ Integer\ Address.o \
	${OBJECTDIR}/Problem\ 5.\ Create\ New\ Integer.o \
	${OBJECTDIR}/Problem\ 6.\ Digit\ Hate.o \
	${OBJECTDIR}/Problem\ 7.\ Generic\ Memory\ Dump\ Function.o \
	${OBJECTDIR}/Problem\ 8.\ Generic\ Swap\ Function.o \
	${OBJECTDIR}/Problem\ 9.\ Clients.o


# C Compiler Flags
CFLAGS=

# CC Compiler Flags
CCFLAGS=
CXXFLAGS=

# Fortran Compiler Flags
FFLAGS=

# Assembler Flags
ASFLAGS=

# Link Libraries and Options
LDLIBSOPTIONS=

# Build Targets
.build-conf: ${BUILD_SUBPROJECTS}
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_pointers.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_pointers.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_pointers ${OBJECTFILES} ${LDLIBSOPTIONS}

.NO_PARALLEL:${OBJECTDIR}/Problem\ 1.\ Swap\ numbers.o
${OBJECTDIR}/Problem\ 1.\ Swap\ numbers.o: Problem\ 1.\ Swap\ numbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 1.\ Swap\ numbers.o Problem\ 1.\ Swap\ numbers.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 2.\ Array\ Print.o
${OBJECTDIR}/Problem\ 2.\ Array\ Print.o: Problem\ 2.\ Array\ Print.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 2.\ Array\ Print.o Problem\ 2.\ Array\ Print.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 3.\ Print\ Array\ Reversed.o
${OBJECTDIR}/Problem\ 3.\ Print\ Array\ Reversed.o: Problem\ 3.\ Print\ Array\ Reversed.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 3.\ Print\ Array\ Reversed.o Problem\ 3.\ Print\ Array\ Reversed.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 4.\ Print\ Integer\ Address.o
${OBJECTDIR}/Problem\ 4.\ Print\ Integer\ Address.o: Problem\ 4.\ Print\ Integer\ Address.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 4.\ Print\ Integer\ Address.o Problem\ 4.\ Print\ Integer\ Address.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 5.\ Create\ New\ Integer.o
${OBJECTDIR}/Problem\ 5.\ Create\ New\ Integer.o: Problem\ 5.\ Create\ New\ Integer.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 5.\ Create\ New\ Integer.o Problem\ 5.\ Create\ New\ Integer.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 6.\ Digit\ Hate.o
${OBJECTDIR}/Problem\ 6.\ Digit\ Hate.o: Problem\ 6.\ Digit\ Hate.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 6.\ Digit\ Hate.o Problem\ 6.\ Digit\ Hate.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 7.\ Generic\ Memory\ Dump\ Function.o
${OBJECTDIR}/Problem\ 7.\ Generic\ Memory\ Dump\ Function.o: Problem\ 7.\ Generic\ Memory\ Dump\ Function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 7.\ Generic\ Memory\ Dump\ Function.o Problem\ 7.\ Generic\ Memory\ Dump\ Function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 8.\ Generic\ Swap\ Function.o
${OBJECTDIR}/Problem\ 8.\ Generic\ Swap\ Function.o: Problem\ 8.\ Generic\ Swap\ Function.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 8.\ Generic\ Swap\ Function.o Problem\ 8.\ Generic\ Swap\ Function.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 9.\ Clients.o
${OBJECTDIR}/Problem\ 9.\ Clients.o: Problem\ 9.\ Clients.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 9.\ Clients.o Problem\ 9.\ Clients.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_9_c_pointers.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
