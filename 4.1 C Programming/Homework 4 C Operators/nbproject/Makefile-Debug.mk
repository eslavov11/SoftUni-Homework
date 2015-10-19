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
	${OBJECTDIR}/AverageSum.o \
	${OBJECTDIR}/BigAndOdd.o \
	${OBJECTDIR}/DivideBy7And5.o \
	${OBJECTDIR}/FourDigitNumber.o \
	${OBJECTDIR}/GravitationOnTheMoon.o \
	${OBJECTDIR}/NthDigit.o \
	${OBJECTDIR}/OddOrEvenIntegers.o \
	${OBJECTDIR}/PointInACircle.o \
	${OBJECTDIR}/PointInsideACircleAndOutsideOfARectangle.o \
	${OBJECTDIR}/PrimeNumberCheck.o \
	${OBJECTDIR}/PureDivisor.o \
	${OBJECTDIR}/Rectangles.o \
	${OBJECTDIR}/ThirdDigitIsSeven.o \
	${OBJECTDIR}/Trapezoids.o


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
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_4_c_operators.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_4_c_operators.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_4_c_operators ${OBJECTFILES} ${LDLIBSOPTIONS}

${OBJECTDIR}/AverageSum.o: AverageSum.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/AverageSum.o AverageSum.c

${OBJECTDIR}/BigAndOdd.o: BigAndOdd.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/BigAndOdd.o BigAndOdd.c

${OBJECTDIR}/DivideBy7And5.o: DivideBy7And5.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/DivideBy7And5.o DivideBy7And5.c

${OBJECTDIR}/FourDigitNumber.o: FourDigitNumber.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/FourDigitNumber.o FourDigitNumber.c

${OBJECTDIR}/GravitationOnTheMoon.o: GravitationOnTheMoon.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/GravitationOnTheMoon.o GravitationOnTheMoon.c

${OBJECTDIR}/NthDigit.o: NthDigit.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/NthDigit.o NthDigit.c

${OBJECTDIR}/OddOrEvenIntegers.o: OddOrEvenIntegers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/OddOrEvenIntegers.o OddOrEvenIntegers.c

${OBJECTDIR}/PointInACircle.o: PointInACircle.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/PointInACircle.o PointInACircle.c

${OBJECTDIR}/PointInsideACircleAndOutsideOfARectangle.o: PointInsideACircleAndOutsideOfARectangle.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/PointInsideACircleAndOutsideOfARectangle.o PointInsideACircleAndOutsideOfARectangle.c

${OBJECTDIR}/PrimeNumberCheck.o: PrimeNumberCheck.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/PrimeNumberCheck.o PrimeNumberCheck.c

${OBJECTDIR}/PureDivisor.o: PureDivisor.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/PureDivisor.o PureDivisor.c

${OBJECTDIR}/Rectangles.o: Rectangles.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Rectangles.o Rectangles.c

${OBJECTDIR}/ThirdDigitIsSeven.o: ThirdDigitIsSeven.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/ThirdDigitIsSeven.o ThirdDigitIsSeven.c

${OBJECTDIR}/Trapezoids.o: Trapezoids.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Trapezoids.o Trapezoids.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_4_c_operators.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
