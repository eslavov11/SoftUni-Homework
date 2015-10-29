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
	${OBJECTDIR}/Problem\ 1.\ Save\ and\ Print\ Numbers\ in\ Range.o \
	${OBJECTDIR}/Problem\ 10.\ Numbers\ Beneath\ Main\ Diagonal.o \
	${OBJECTDIR}/Problem\ 11.\ Scalar\ Multiplication\ of\ a\ Vector.o \
	${OBJECTDIR}/Problem\ 12.\ Dot\ Product\ of\ vectors.o \
	${OBJECTDIR}/Problem\ 14.\ Sum\ of\ Matrices.o \
	${OBJECTDIR}/Problem\ 15.\ Multiplication\ of\ Matrices.o \
	${OBJECTDIR}/Problem\ 2.\ Linear\ Search.o \
	${OBJECTDIR}/Problem\ 3.\ Sort\ Array\ of\ Numbers.o \
	${OBJECTDIR}/Problem\ 4.\ Categorize\ Numbers.o \
	${OBJECTDIR}/Problem\ 5.\ Longest\ Increasing\ Sequence.o \
	${OBJECTDIR}/Problem\ 6.\ Join\ Lists.o \
	${OBJECTDIR}/Problem\ 7.\ Reverse\ Array.o \
	${OBJECTDIR}/Problem\ 8.\ Iterative\ Binary\ Search.o


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
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_8_c_arrays.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_8_c_arrays.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_8_c_arrays ${OBJECTFILES} ${LDLIBSOPTIONS}

.NO_PARALLEL:${OBJECTDIR}/Problem\ 1.\ Save\ and\ Print\ Numbers\ in\ Range.o
${OBJECTDIR}/Problem\ 1.\ Save\ and\ Print\ Numbers\ in\ Range.o: Problem\ 1.\ Save\ and\ Print\ Numbers\ in\ Range.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 1.\ Save\ and\ Print\ Numbers\ in\ Range.o Problem\ 1.\ Save\ and\ Print\ Numbers\ in\ Range.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 10.\ Numbers\ Beneath\ Main\ Diagonal.o
${OBJECTDIR}/Problem\ 10.\ Numbers\ Beneath\ Main\ Diagonal.o: Problem\ 10.\ Numbers\ Beneath\ Main\ Diagonal.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 10.\ Numbers\ Beneath\ Main\ Diagonal.o Problem\ 10.\ Numbers\ Beneath\ Main\ Diagonal.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 11.\ Scalar\ Multiplication\ of\ a\ Vector.o
${OBJECTDIR}/Problem\ 11.\ Scalar\ Multiplication\ of\ a\ Vector.o: Problem\ 11.\ Scalar\ Multiplication\ of\ a\ Vector.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 11.\ Scalar\ Multiplication\ of\ a\ Vector.o Problem\ 11.\ Scalar\ Multiplication\ of\ a\ Vector.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 12.\ Dot\ Product\ of\ vectors.o
${OBJECTDIR}/Problem\ 12.\ Dot\ Product\ of\ vectors.o: Problem\ 12.\ Dot\ Product\ of\ vectors.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 12.\ Dot\ Product\ of\ vectors.o Problem\ 12.\ Dot\ Product\ of\ vectors.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 14.\ Sum\ of\ Matrices.o
${OBJECTDIR}/Problem\ 14.\ Sum\ of\ Matrices.o: Problem\ 14.\ Sum\ of\ Matrices.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 14.\ Sum\ of\ Matrices.o Problem\ 14.\ Sum\ of\ Matrices.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 15.\ Multiplication\ of\ Matrices.o
${OBJECTDIR}/Problem\ 15.\ Multiplication\ of\ Matrices.o: Problem\ 15.\ Multiplication\ of\ Matrices.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 15.\ Multiplication\ of\ Matrices.o Problem\ 15.\ Multiplication\ of\ Matrices.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 2.\ Linear\ Search.o
${OBJECTDIR}/Problem\ 2.\ Linear\ Search.o: Problem\ 2.\ Linear\ Search.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 2.\ Linear\ Search.o Problem\ 2.\ Linear\ Search.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 3.\ Sort\ Array\ of\ Numbers.o
${OBJECTDIR}/Problem\ 3.\ Sort\ Array\ of\ Numbers.o: Problem\ 3.\ Sort\ Array\ of\ Numbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 3.\ Sort\ Array\ of\ Numbers.o Problem\ 3.\ Sort\ Array\ of\ Numbers.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 4.\ Categorize\ Numbers.o
${OBJECTDIR}/Problem\ 4.\ Categorize\ Numbers.o: Problem\ 4.\ Categorize\ Numbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 4.\ Categorize\ Numbers.o Problem\ 4.\ Categorize\ Numbers.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 5.\ Longest\ Increasing\ Sequence.o
${OBJECTDIR}/Problem\ 5.\ Longest\ Increasing\ Sequence.o: Problem\ 5.\ Longest\ Increasing\ Sequence.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 5.\ Longest\ Increasing\ Sequence.o Problem\ 5.\ Longest\ Increasing\ Sequence.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 6.\ Join\ Lists.o
${OBJECTDIR}/Problem\ 6.\ Join\ Lists.o: Problem\ 6.\ Join\ Lists.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 6.\ Join\ Lists.o Problem\ 6.\ Join\ Lists.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 7.\ Reverse\ Array.o
${OBJECTDIR}/Problem\ 7.\ Reverse\ Array.o: Problem\ 7.\ Reverse\ Array.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 7.\ Reverse\ Array.o Problem\ 7.\ Reverse\ Array.c

.NO_PARALLEL:${OBJECTDIR}/Problem\ 8.\ Iterative\ Binary\ Search.o
${OBJECTDIR}/Problem\ 8.\ Iterative\ Binary\ Search.o: Problem\ 8.\ Iterative\ Binary\ Search.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Problem\ 8.\ Iterative\ Binary\ Search.o Problem\ 8.\ Iterative\ Binary\ Search.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_8_c_arrays.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
